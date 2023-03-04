import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableChamadoComponent } from './table-chamado.component';

describe('TableChamadoComponent', () => {
  let component: TableChamadoComponent;
  let fixture: ComponentFixture<TableChamadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableChamadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableChamadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
