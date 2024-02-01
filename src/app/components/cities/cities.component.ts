import { Component, OnInit } from '@angular/core';
import { CityVM } from '../../models/city.model';
import { CitiesService } from '../../services/cities.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css'],
})
export class CitiesComponent implements OnInit {
  cities: CityVM[] = [];
  citiesFiltered: CityVM[] = [];
  citiesSelected: CityVM[] = [];

  noResults: boolean = false;
  noResultsMsg: string = 'אין יישובים מתאימים לחיפוש';
  cityForEdit: CityVM | null = null;
  sortDescendingActive: boolean = false;
  sortDescendingTxt: string = 'מיון בסדר עולה';
  sortAscendingTxt: string = 'מיון בסדר יורד';
  pageSize: number = 5;
  page = 1;

  constructor(private citiesService: CitiesService) {}

  ngOnInit(): void {
    this.citiesService.getAllCities().subscribe(
      (response) => {
        this.cities = response;
        this.citiesFiltered = this.cities;
        console.log(this.cities);
      },
      (error) => console.error(`error: ${error}`)
    );
  }

  clearFilter() {
    this.citiesFiltered = this.cities;
  }

  search(event: any) {
    var value = event.target.value;
    if (value != null && value.length > 0) {
      this.citiesFiltered = this.cities.filter((city) =>
        city.cityName.includes(value)
      );
      if (this.citiesFiltered.length < 1) {
        this.noResults = true;
      }
    } else {
      this.clearFilter();
    }
  }

  add(city: CityVM) {
    this.citiesSelected.push(city);
    this.delete(city);
  }

  edit(city: CityVM) {
    this.cityForEdit = city;
  }

  saveChanges(newValue: string) {
    if (newValue && newValue.length > 0) {
      let index = this.citiesFiltered.indexOf(this.cityForEdit!);
      this.citiesFiltered[index] = { cityName: newValue };
      index = this.cities.indexOf(this.cityForEdit!);
      this.cities[index] = { cityName: newValue };
    }
  }

  delete(city: CityVM) {
    let index = this.citiesFiltered.indexOf(city);
    this.citiesFiltered.splice(index, 1);
    index = this.cities.indexOf(city);
    this.cities.splice(index, 1);
  }

  sortData() {
    this.citiesFiltered.reverse();
    this.sortDescendingActive = !this.sortDescendingActive;
  }
}
