import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CityVM } from '../models/city.model';

@Injectable({
  providedIn: 'root',
})
export class CitiesService {
  private baseUrl: string = '';
  private api: string = 'CitiesManagement';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') apiBaseUrl: string
  ) {
    this.baseUrl = apiBaseUrl;
  }

  //Get all cities from server:
  getAllCities(): Observable<CityVM[]> {
    var res = this.http.get<CityVM[]>(this.baseUrl + this.api);
    console.log(res);
    return res;
  }
}
