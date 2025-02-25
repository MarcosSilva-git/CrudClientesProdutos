import { Component, OnInit, ViewChild, AfterViewInit, inject } from '@angular/core'
import { ClientsService } from "./clients.service"
import { Client } from "./models/client.model"
import { PagedResponse } from '../../core/models/paged-response.model'
import { CommonModule } from '@angular/common'
import { MatTableDataSource, MatTableModule } from '@angular/material/table'
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { ClientCreateUpdateDialogComponent, ClientCreateUpdateDialogData } from './components/client-create-update-dialog/client-create-update-dialog.component'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'app-client-page',
  imports: [CommonModule, MatTableModule, MatIconModule, MatPaginatorModule, MatButtonModule ],
  standalone: true,
  templateUrl: './client.page.html',
  styleUrl: './client.page.css'
})
export class ClientPage implements OnInit, AfterViewInit {
  products?: PagedResponse<Client>
  displayedColumns: string[] = ['id', 'name', 'email', 'phoneNumber', 'active', 'actions']
  dataSource = new MatTableDataSource<Client>([])

  @ViewChild(MatPaginator) paginator?: MatPaginator;

  constructor(private _clientService : ClientsService) { }

  readonly dialog = inject(MatDialog);

  openDialog(client?: Client): void {
    console.log(client)
    const dialogRef = this.dialog.open<ClientCreateUpdateDialogComponent, ClientCreateUpdateDialogData>(
      ClientCreateUpdateDialogComponent, {
      data: {
        client: client,
        title: client  ? 'Editar Cliente' : 'Criar Cliente' 
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getClients(this.paginator!.pageIndex, this.paginator!.pageSize)
      }
    });
  }

  ngAfterViewInit() {
    this.paginator!.page.subscribe((event : any) => {
      this.getClients(event.pageIndex, event.pageSize);
    });
  }

  ngOnInit(): void {
    this.getClients();
  }

  updateTable() {
    this.dataSource.data = this.products!.items

    if (this.paginator) {
      this.paginator.length = this.products!.totalItems
    }
  }

  getClients(pageIndex: number = 0, pageSize: number = 5): void {
    console.log(pageIndex, pageSize)
    this._clientService.get(pageSize, pageIndex).subscribe({
      next: (response: PagedResponse<Client>) => {
        console.log(response)
        this.products = response
        this.updateTable()
      },
      error: () => alert('Erro ao carregar produtos:')
    });
  }

  deleteClient(client: Client): void {
    this._clientService.delete(client.id)
      .subscribe({
        next: () => {
          this.getClients(this.paginator!.pageIndex, this.paginator!.pageSize)
        }
      })
  }
}
