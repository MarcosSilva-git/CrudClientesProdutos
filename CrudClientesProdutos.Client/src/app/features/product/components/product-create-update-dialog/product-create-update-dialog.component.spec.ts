import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCreateUpdateDialogComponent } from './product-create-update-dialog.component';

describe('ProductCreateDialogComponent', () => {
  let component: ProductCreateUpdateDialogComponent;
  let fixture: ComponentFixture<ProductCreateUpdateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProductCreateUpdateDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductCreateUpdateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
