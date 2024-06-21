import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupoGastoComponent } from './grupo-gasto.component';

describe('GrupoGastoComponent', () => {
  let component: GrupoGastoComponent;
  let fixture: ComponentFixture<GrupoGastoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GrupoGastoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GrupoGastoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
