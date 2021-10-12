CREATE TABLE IF NOT EXISTS `clientes` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `CPF` varchar(11) NOT NULL,
  `Email` varchar(56) NOT NULL,
  `Telefone` varchar(8) NOT NULL,
  `Sexo` char(1) NOT NULL,
  `DataNascimento` date NOT NULL
  PRIMARY KEY (`id`)
) 