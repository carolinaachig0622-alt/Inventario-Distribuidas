CREATE DATABASE InventarioDB;
GO
USE InventarioDB;
GO

CREATE TABLE Bodegas (
    IdBodega INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    Ubicacion NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Existencias (
    IdExistencia INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad INT NOT NULL,
    IdBodega INT NOT NULL,
    IdProducto INT NOT NULL,
    FOREIGN KEY (IdBodega) REFERENCES Bodegas(IdBodega)
);

CREATE TABLE MovimientosInv (
    IdMovimientoInv INT IDENTITY(1,1) PRIMARY KEY,
    Tipo NVARCHAR(MAX) NOT NULL,
    Cantidad INT NOT NULL,
    Fecha DATETIME2 NOT NULL,
    IdBodega INT NOT NULL,
    IdProducto INT NOT NULL,
    FOREIGN KEY (IdBodega) REFERENCES Bodegas(IdBodega)
);
