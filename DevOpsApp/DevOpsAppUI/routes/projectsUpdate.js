'use strict';
var express = require('express');
var router = express.Router();

process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0'; // Deshabilitar validación SSL

// Ruta para mostrar el formulario de edición
router.get('/:id', async function (req, res) {
    try {
        const API_URL_PROJECTS = req.app.locals.config.API_URL_PROJECTS;
        const projectId = req.params.id;

        // Obtener los datos del proyecto
        const response = await fetch(`${API_URL_PROJECTS}/${projectId}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`Error al obtener el proyecto: ${response.statusText}`);
        }

        const project = await response.json();
        res.render('projectsUpdate', { title: 'Editar Proyecto', project });
    } catch (error) {
        console.error('Error al obtener proyecto:', error);
        res.status(500).send('Error al obtener el proyecto');
    }
});

// Ruta para actualizar el proyecto
router.post('/:id', async function (req, res) {
    try {
        const { title, description, repository } = req.body;
        const projectId = req.params.id;
        const API_URL_PROJECTS = req.app.locals.config.API_URL_PROJECTS;
        const body = JSON.stringify({
            id: projectId,
            title,
            description,
            repository
        });

        const response = await fetch(`${API_URL_PROJECTS}/${projectId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: body
        });

        if (!response.ok) {
            throw new Error(`Error al actualizar el proyecto: ${response.statusText}`);
        }

        res.redirect('/projects');
    } catch (error) {
        console.error('Error al actualizar proyecto:', error);
        res.status(500).send('Error al actualizar proyecto');
    }
});

module.exports = router;
