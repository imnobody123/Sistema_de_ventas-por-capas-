-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema sistema_de_ventas
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sistema_de_ventas
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sistema_de_ventas` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `sistema_de_ventas` ;

-- -----------------------------------------------------
-- Table `sistema_de_ventas`.`clientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistema_de_ventas`.`clientes` (
  `IdCliente` INT(11) NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  `Apellidos` VARCHAR(30) NOT NULL,
  `Direccion` VARCHAR(45) NOT NULL,
  `Telefono` INT(11) NOT NULL,
  PRIMARY KEY (`IdCliente`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sistema_de_ventas`.`empleados`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistema_de_ventas`.`empleados` (
  `IdEmpleado` INT(11) NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(30) NOT NULL,
  `ApellidoP` VARCHAR(15) NOT NULL,
  `ApellidoM` VARCHAR(15) NOT NULL,
  `Sexo` VARCHAR(10) NOT NULL,
  `EstadoCivil` VARCHAR(10) NOT NULL,
  `FechaN` DATE NOT NULL,
  `Direccion` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`IdEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sistema_de_ventas`.`productos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistema_de_ventas`.`productos` (
  `IdProductos` INT(11) NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  `Descripcion` VARCHAR(60) NOT NULL,
  `Stock` INT(11) NOT NULL,
  `PrecioCompra` DECIMAL(10,0) NOT NULL,
  `PrecioVenta` DECIMAL(10,0) NOT NULL,
  `FechaVencimiento` DATE NOT NULL,
  PRIMARY KEY (`IdProductos`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sistema_de_ventas`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistema_de_ventas`.`usuarios` (
  `IdUsuario` INT(11) NOT NULL AUTO_INCREMENT,
  `Usuario` VARCHAR(45) NOT NULL,
  `Contrasena` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdUsuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sistema_de_ventas`.`venta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sistema_de_ventas`.`venta` (
  `IdVenta` INT(11) NOT NULL AUTO_INCREMENT,
  `IdEmpleado` INT NOT NULL,
  `IdProductos` INT(11) NOT NULL,
  `IdCliente` INT(11) NOT NULL,
  `CantidadComprada` INT(10) NOT NULL,
  `TipoDocumento` VARCHAR(60) NOT NULL,
  `NumeroDocumento` INT(11) NOT NULL,
  `FechaVenta` DATE NOT NULL,
  `PrecioTotal` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`IdVenta`),
  INDEX `fk_venta_clientes1_idx` (`IdCliente` ASC) VISIBLE,
  INDEX `fk_venta_productos1_idx` (`IdProductos` ASC) VISIBLE,
  INDEX `fk_venta_empleados1_idx` (`IdEmpleado` ASC) VISIBLE,
  CONSTRAINT `fk_venta_clientes1`
    FOREIGN KEY (`IdCliente`)
    REFERENCES `sistema_de_ventas`.`clientes` (`IdCliente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_venta_productos1`
    FOREIGN KEY (`IdProductos`)
    REFERENCES `sistema_de_ventas`.`productos` (`IdProductos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_venta_empleados1`
    FOREIGN KEY (`IdEmpleado`)
    REFERENCES `sistema_de_ventas`.`empleados` (`IdEmpleado`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `sistema_de_ventas`.`clientes`
-- -----------------------------------------------------
START TRANSACTION;
USE `sistema_de_ventas`;
INSERT INTO `sistema_de_ventas`.`clientes` (`IdCliente`, `Nombre`, `Apellidos`, `Direccion`, `Telefono`) VALUES (1, 'Angelica', 'Aguilar', 'Contreras', 55789545);
INSERT INTO `sistema_de_ventas`.`clientes` (`IdCliente`, `Nombre`, `Apellidos`, `Direccion`, `Telefono`) VALUES (2, 'Luisa', 'Mendoza', 'Ramirez', 25697425);
INSERT INTO `sistema_de_ventas`.`clientes` (`IdCliente`, `Nombre`, `Apellidos`, `Direccion`, `Telefono`) VALUES (3, 'Alex', 'Zavala', 'Jimenéz', 48956631);
INSERT INTO `sistema_de_ventas`.`clientes` (`IdCliente`, `Nombre`, `Apellidos`, `Direccion`, `Telefono`) VALUES (4, 'Miguel', 'Lunar', 'Pacheco', 45654410);
INSERT INTO `sistema_de_ventas`.`clientes` (`IdCliente`, `Nombre`, `Apellidos`, `Direccion`, `Telefono`) VALUES (5, 'Tribio', 'Pedro', 'Pablo', 45230045);

COMMIT;


-- -----------------------------------------------------
-- Data for table `sistema_de_ventas`.`empleados`
-- -----------------------------------------------------
START TRANSACTION;
USE `sistema_de_ventas`;
INSERT INTO `sistema_de_ventas`.`empleados` (`IdEmpleado`, `Nombre`, `ApellidoP`, `ApellidoM`, `Sexo`, `EstadoCivil`, `FechaN`, `Direccion`) VALUES (1, 'Juan', 'Rivera', 'Ruiz', 'Masculino', 'Soltero', '1987-06-23', 'Zona centro');
INSERT INTO `sistema_de_ventas`.`empleados` (`IdEmpleado`, `Nombre`, `ApellidoP`, `ApellidoM`, `Sexo`, `EstadoCivil`, `FechaN`, `Direccion`) VALUES (2, 'Luis', 'Canchola', 'Lozano', 'Masculino', 'Soltero', '1986-06-22', 'Zona Centro');
INSERT INTO `sistema_de_ventas`.`empleados` (`IdEmpleado`, `Nombre`, `ApellidoP`, `ApellidoM`, `Sexo`, `EstadoCivil`, `FechaN`, `Direccion`) VALUES (3, 'Paloma', 'Hernandez', 'Aguilar', 'Femenino', 'Soltera', '1990-01-18', 'Zona centro');
INSERT INTO `sistema_de_ventas`.`empleados` (`IdEmpleado`, `Nombre`, `ApellidoP`, `ApellidoM`, `Sexo`, `EstadoCivil`, `FechaN`, `Direccion`) VALUES (4, 'Nepomuzeno', 'Rodriguez', 'Rodriguez', 'Masculino', 'Soltero', '1962-12-25', 'Zona Centro');
INSERT INTO `sistema_de_ventas`.`empleados` (`IdEmpleado`, `Nombre`, `ApellidoP`, `ApellidoM`, `Sexo`, `EstadoCivil`, `FechaN`, `Direccion`) VALUES (5, 'Agustin', 'Melgar', 'Casas', 'Masculino', 'Casado', '1978-02-11', 'Zona centro');

COMMIT;


-- -----------------------------------------------------
-- Data for table `sistema_de_ventas`.`productos`
-- -----------------------------------------------------
START TRANSACTION;
USE `sistema_de_ventas`;
INSERT INTO `sistema_de_ventas`.`productos` (`IdProductos`, `Nombre`, `Descripcion`, `Stock`, `PrecioCompra`, `PrecioVenta`, `FechaVencimiento`) VALUES (1, 'Fabuloso', 'Producto de limpieza', 40, 8, 15, '2000-01-01');
INSERT INTO `sistema_de_ventas`.`productos` (`IdProductos`, `Nombre`, `Descripcion`, `Stock`, `PrecioCompra`, `PrecioVenta`, `FechaVencimiento`) VALUES (2, 'Sabritas', 'Producto comestible', 15, 9.00, 10.00, '2019-12-15');
INSERT INTO `sistema_de_ventas`.`productos` (`IdProductos`, `Nombre`, `Descripcion`, `Stock`, `PrecioCompra`, `PrecioVenta`, `FechaVencimiento`) VALUES (3, 'Coca Cola', 'Producto bebible', 12, 8.00, 12.00, '2020-01-18');
INSERT INTO `sistema_de_ventas`.`productos` (`IdProductos`, `Nombre`, `Descripcion`, `Stock`, `PrecioCompra`, `PrecioVenta`, `FechaVencimiento`) VALUES (4, 'Cebollas', 'Producto comestible', 25, 3.00, 5.00, '2020-02-19');
INSERT INTO `sistema_de_ventas`.`productos` (`IdProductos`, `Nombre`, `Descripcion`, `Stock`, `PrecioCompra`, `PrecioVenta`, `FechaVencimiento`) VALUES (5, 'Jitomate', 'Producto comestible', 24, 4.00, 6.00, '2020-01-25');

COMMIT;


-- -----------------------------------------------------
-- Data for table `sistema_de_ventas`.`usuarios`
-- -----------------------------------------------------
START TRANSACTION;
USE `sistema_de_ventas`;
INSERT INTO `sistema_de_ventas`.`usuarios` (`IdUsuario`, `Usuario`, `Contrasena`) VALUES (1, 'Juan Cano', '827ccb0eea8a706c4c34a16891f84e7b');
INSERT INTO `sistema_de_ventas`.`usuarios` (`IdUsuario`, `Usuario`, `Contrasena`) VALUES (2, 'Agustin Melgar', '01cfcd4f6b8770febfb40cb906715822');
INSERT INTO `sistema_de_ventas`.`usuarios` (`IdUsuario`, `Usuario`, `Contrasena`) VALUES (3, 'Luis Espitia', '6789');
INSERT INTO `sistema_de_ventas`.`usuarios` (`IdUsuario`, `Usuario`, `Contrasena`) VALUES (4, 'Moises Suarex', '9876');
INSERT INTO `sistema_de_ventas`.`usuarios` (`IdUsuario`, `Usuario`, `Contrasena`) VALUES (5, 'Benito Camelo', 'Benito09');

COMMIT;