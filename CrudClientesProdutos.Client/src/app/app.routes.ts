import { Route, Routes } from '@angular/router';
import { MainLayout } from './layouts/main/main.layout';
import { PRODUCT_ROUTES } from './features/product/product.routes';

// export const routes: Routes = [
//     { path: '', redirectTo: '/products', pathMatch: 'full' },
//     {
//         path: 'products',
//         loadChildren: () => import('./features/product/product.routes').then(m => m.PRODUCT_ROUTES),
//     },
//     {
//         path: 'clients',
//         loadChildren: () => import('./features/client/client.routes').then(m => m.CLIENT_ROUTES),
//     },
// ];


export const routes: Routes = [
    {
        path: '',
        component: MainLayout,
        children: [
            { path: '', redirectTo: '/products', pathMatch: 'full' },
            {
                path: 'products',
                loadChildren: () => import('./features/product/product.routes').then(m => m.PRODUCT_ROUTES),
            },
            {
                path: 'clients',
                loadChildren: () => import('./features/client/client.routes').then(m => m.CLIENT_ROUTES),
            },
        ]
    }
]
