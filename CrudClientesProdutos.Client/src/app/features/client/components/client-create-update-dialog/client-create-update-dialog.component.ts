import { Component, inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef, MatDialogModule, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldControl, MatFormFieldModule, MatPrefix } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { Client } from '../../models/client.model';
import { ClientsService } from '../../clients.service';
import { MatIconModule } from '@angular/material/icon';

export interface ClientCreateUpdateDialogData {
  client?: Client
  title: string
}

type ClientForm = {
  name: FormControl<string | null>;
  email: FormControl<string | null>;
  phoneNumber: FormControl<string | null>;
  active: FormControl<boolean | null>;
};

@Component({
  selector: 'app-client-create-update-dialog',
  imports: [MatDialogModule, MatIconModule, MatPrefix, MatCheckboxModule, MatButtonModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  standalone: true,
  templateUrl: './client-create-update-dialog.component.html',
  styleUrl: './client-create-update-dialog.component.css'
})
export class ClientCreateUpdateDialogComponent implements OnInit {
  readonly _clientService = inject(ClientsService)
  readonly dialogRef = inject(MatDialogRef<ClientCreateUpdateDialogComponent>);
  readonly data: ClientCreateUpdateDialogData = inject(MAT_DIALOG_DATA);

  clientForm = new FormGroup<ClientForm>({
    name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]),
    email: new FormControl(null, [Validators.required, this.validateEmailExtension]),
    phoneNumber: new FormControl(null, [this.validatePhoneNumber]),
    active: new FormControl(true, [Validators.required]),
  });

  cancel(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
      this.clientForm.patchValue(this.data.client ?? {})
  }

  validateEmailExtension(control: AbstractControl): ValidationErrors | null {
    var validEmail = Validators.email(control);

    if (validEmail !== null) {
      return validEmail
    }

    if (control.value !== null) {
      var dotIndex = control.value.toString().split('@')[1].indexOf('.')
      console.log(dotIndex)
      if (dotIndex === -1 || control.value.toString().endsWith('.')) {
        return { 'invalidEmail': 'O email precisa ser válido' }
      }
    }

    return null
  }

  validatePhoneNumber(control: AbstractControl): ValidationErrors | null {
    const phone = control.value;
  
    console.log(phone)
    // Check if the phone number is valid (length should be at least 9)
    if (phone && phone?.toString().length != 11) {
      return { 'invalidPhone': 'Celular inválido' };
    }
  
    return null; 
  }

  getErrorMessage(field: string) : string {
    const control = this.clientForm.get(field);
    
    if (field == 'n') {
      console.log(control?.value)
    }
    if (control?.hasError('required')) {
      return 'Obrigatório';
    }

    if (field === 'name') {
      if (control?.hasError('minlength') ) {
        return `O ${field} deve ter pelo menos 3 caracteres`;
      }
      if (control?.hasError('maxlength')) {
        return `O ${field} deve ter no máximo 100 caracteres`;
      }
    }

    if (field === 'email') {
      return 'O email precisa ser válido'
    }

    if (field === 'phoneNumber' && control!.invalid)
    {
        return 'Celular inválido'
    }
    return '';
  }

  createClient(clientForm: FormGroup<ClientForm>) {
      const client : Omit<Client, 'id'> = {
        name: clientForm.value.name!,
        email: clientForm.value.email!, 
        phoneNumber: clientForm.value.phoneNumber?.toString(), 
      }
      
      this._clientService
        .create(client)
        .subscribe({
          next: () => {
            alert(`Cliente criado`)
            this.dialogRef.close(client);
          },
          error: e => {
            alert("Ocorreu um erro inesperado, tente novamente em alguns instantes")
          }
        })
  }

  updateClient(clientForm: FormGroup<ClientForm>) {
    const client : Client = {
      id: this.data.client!.id,
      name: clientForm.value.name!,
      email: clientForm.value.email!, 
      phoneNumber: clientForm.value.phoneNumber?.toString(), 
    }

    this._clientService
      .update(client)
      .subscribe({
        next: () => {
          alert(`Cliente atualizado`)
          this.dialogRef.close(client);
        },
        error: () => {
          alert("Ocorreu um erro inesperado, tente novamente em alguns instantes")
        }
      })
  }

  submit() {
    if (this.clientForm.valid) {
      if (this.data.client) {
        this.updateClient(this.clientForm)
      } else {
          this.createClient(this.clientForm)
      } 
    }
  }
}
