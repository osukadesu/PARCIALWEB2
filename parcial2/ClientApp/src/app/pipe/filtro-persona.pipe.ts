import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from '../parcial2/models/persona';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  transform(persona: Persona[], searchText: string): any {
    if (searchText == null) return persona;
    return persona.filter(p =>
      p.cedula.toLowerCase()
        .indexOf(searchText.toLowerCase()) !== -1);
  }
}
