import { Routes } from '@angular/router';
import { MainLayout } from './layouts/main/main.layout';

export const routes: Routes = [
    {
        path: '',
        component: MainLayout,
        children: [
            { path: '', redirectTo: '/produtos', pathMatch: 'full' },
            {
                path: 'produtos',
                loadChildren: () => import('./features/product/product.routes').then(m => m.PRODUCT_ROUTES),
            },
            {
                path: 'clientes',
                loadChildren: () => import('./features/client/client.routes').then(m => m.CLIENT_ROUTES),
            },
        ]
    }
]
