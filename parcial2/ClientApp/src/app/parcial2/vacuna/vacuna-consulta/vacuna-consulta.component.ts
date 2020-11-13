import { Component, OnInit } from '@angular/core';
import { VacunaService } from 'src/app/services/vacuna.service';
import { Vacuna } from '../../models/vacuna';

@Component({
  selector: 'app-vacuna-consulta',
  templateUrl: './vacuna-consulta.component.html',
  styleUrls: ['./vacuna-consulta.component.css']
})
export class VacunaConsultaComponent implements OnInit {
  vacunas: Vacuna[];
  searchText: string;
  constructor(private vacunaService: VacunaService) { }

  ngOnInit(){
    this.vacunaService.get().subscribe(result => {
      this.vacunas = result;
      });
  }

    /*Ordenar en la tabla*/

    sortTable(n) {
      var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
      table = document.getElementById("myTable");
      switching = true;
      dir = "asc";
      while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
          shouldSwitch = false;
          x = rows[i].getElementsByTagName("TD")[n];
          y = rows[i + 1].getElementsByTagName("TD")[n];
          if (dir == "asc") {
            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
              shouldSwitch = true;
              break;
            }
          }
          else if (dir == "desc") {
            if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
              shouldSwitch = true;
              break;
            }
          }
        }
        if (shouldSwitch) {
          rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
          switching = true;
          switchcount++;
        }
        else {
          if (switchcount == 0 && dir == "asc") {
            dir = "desc";
            switching = true;
          }
        }
      }
    }
}
