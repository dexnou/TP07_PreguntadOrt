CREATE TABLE Categorias (
  IdCategoria INT PRIMARY KEY,
  Nombre VARCHAR(100),
  Foto VARCHAR(255)
);
CREATE TABLE Dificultades (
  IdDificultad INT PRIMARY KEY,
  Nombre VARCHAR(100)
);


CREATE TABLE Preguntas (
  IdPregunta INT PRIMARY KEY,
  IdCategoria INT,
  IdDificultad INT,
  Enunciado VARCHAR(500),
  Foto VARCHAR(255),
  FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria),
  FOREIGN KEY (IdDificultad) REFERENCES Dificultades(IdDificultad)
);

CREATE TABLE Respuestas (
  IdRespuesta INT PRIMARY KEY,
  IdPregunta INT,
  Opcion INT,
  Contenido VARCHAR(500),
  Correcta BIT,
  Foto VARCHAR(255),
  FOREIGN KEY (IdPregunta) REFERENCES Preguntas(IdPregunta)
);

