import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  name: string;
  //temperatureC: number;
  //temperatureF: number;
  //summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  imports: [HttpClientModule],
  standalone: true,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('https://localhost:7163/api/v1/Client').subscribe(
      result => {
        this.forecasts = result;
      },
      error => {
        console.error(error);
      }
    );
  }

  title = 'crudclientesprodutos.client';
}
