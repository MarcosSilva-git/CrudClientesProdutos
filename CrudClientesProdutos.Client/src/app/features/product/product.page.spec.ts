import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductPage } from './product.page';

describe('ProductComponent', () => {
  let component: ProductPage;
  let fixture: ComponentFixture<ProductPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProductPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
