CREATE DATABASE IF NOT EXISTS devopsapp;
USE devopsapp;

CREATE TABLE IF NOT EXISTS projects (
    project_index INT AUTO_INCREMENT PRIMARY KEY,
    project_id CHAR(36) NOT NULL,
    project_title VARCHAR(255) NOT NULL,
    project_description TEXT,
    project_repository VARCHAR(255),
    UNIQUE KEY (project_index)
);
