import { Component } from '@angular/core'
import { MatToolbarModule } from '@angular/material/toolbar'
import { RouterModule } from '@angular/router'

@Component({
  selector: 'app-main-layout',
  imports: [MatToolbarModule, RouterModule],
  standalone: true,
  templateUrl: './main.layout.html',
  styleUrl: './main.layout.css'
})
export class MainLayout {

}
