CREATE DATABASE mantenimientos;
use mantenimientos;

CREATE TABLE Tbl_puesto (
	pk_codigo_puesto VARCHAR(5),
    nombre_puesto VARCHAR(60),
    estatus_puesto VARCHAR(1),
    PRIMARY KEY (pk_codigo_puesto)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE Tbl_departamento (
	pk_codigo_departamento VARCHAR(5),
    nombre_departamento VARCHAR(80),
    estatus_departamento VARCHAR(1),
    PRIMARY KEY (pk_codigo_departamento)	
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

drop table Tbl_empleado;

CREATE TABLE Tbl_empleado (
    pk_codigo_empleado VARCHAR(5),
    nombre_empleado VARCHAR(60),
    pk_codigo_puesto VARCHAR(5),
    pk_codigo_departamento VARCHAR(5),
    sueldo_empleado int,
    estatus_empleado VARCHAR(1),
    PRIMARY KEY (pk_codigo_empleado),
    CONSTRAINT FK_puestoempleado FOREIGN KEY (pk_codigo_puesto) REFERENCES Tbl_puesto (pk_codigo_puesto),
    CONSTRAINT FK_departamentoempleado FOREIGN KEY (pk_codigo_departamento) REFERENCES Tbl_departamento (pk_codigo_departamento)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;