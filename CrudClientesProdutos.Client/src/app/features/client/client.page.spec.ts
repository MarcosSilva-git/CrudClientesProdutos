import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientPage } from './client.page';

describe('ProductComponent', () => {
  let component: ClientPage;
  let fixture: ComponentFixture<ClientPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClientPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
