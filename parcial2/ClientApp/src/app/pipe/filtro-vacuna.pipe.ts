import { Pipe, PipeTransform } from '@angular/core';
import { Vacuna } from '../parcial2/models/vacuna';

@Pipe({
  name: 'filtroVacuna'
})
export class FiltroVacunaPipe implements PipeTransform {

  transform(vacuna: Vacuna[], searchText: string): any {
    if (searchText == null) return vacuna;
    return vacuna.filter(p =>
      p.idvacuna.toLowerCase()
        .indexOf(searchText.toLowerCase()) !== -1);
  }
}
