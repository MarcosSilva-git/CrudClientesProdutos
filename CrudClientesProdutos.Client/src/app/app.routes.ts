import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: '/products', pathMatch: 'full' },
    {
        path: 'products',
        loadChildren: () => import('./features/products/product.routes').then(m => m.PRODUCT_ROUTES),
    },
    {
        path: 'clients',
        loadChildren: () => import('./features/clients/client.routes').then(m => m.CLIENT_ROUTES),
    },
];
