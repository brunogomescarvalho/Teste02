import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IChamado } from 'src/app/model';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router) { }

  chamado!: IChamado;

  ngOnInit(): void {
    this.chamado = this.route.snapshot.data['chamado'];
  }

}
