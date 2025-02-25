import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientCreateUpdateDialogComponent } from './client-create-update-dialog.component';

describe('ClientCreateUpdateDialogComponent', () => {
  let component: ClientCreateUpdateDialogComponent;
  let fixture: ComponentFixture<ClientCreateUpdateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClientCreateUpdateDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientCreateUpdateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
