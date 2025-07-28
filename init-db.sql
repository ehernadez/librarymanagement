-- Script para crear la base de datos y la tabla de libros en PostgreSQL
CREATE DATABASE library;

-- Ejecuta lo siguiente dentro de la base de datos 'library'
CREATE TABLE IF NOT EXISTS "Books" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "Author" VARCHAR(255) NOT NULL,
    "Year" INT NOT NULL,
    "ISBN" VARCHAR(50) NOT NULL
);
