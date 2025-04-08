'use strict';
const express = require('express');
const router = express.Router();
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0'; // ignorar SSL si es necesario

// Ver tareas de un proyecto
router.get('/:projectId', async function (req, res) {
    const projectId = req.params.projectId;
    const API_URL = req.app.locals.config.API_URL_PROJECTS_TASKS;
    console.log('API_URL');
    console.log(`${API_URL}/GetAll/${projectId}`);
    try {
        const response = await fetch(`${API_URL}/GetAll/${projectId}`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        });

        if (!response.ok) throw new Error(`Error al obtener tareas: ${response.statusText}`);

        const tasks = await response.json();
        res.render('projectsTasks', { title: 'Tareas', tasks, projectId });
    } catch (error) {
        console.error('Error:', error);
        res.status(500).send('Error al obtener tareas');
    }
});

// Formulario para agregar tarea
router.get('/:projectId/tasks/new', (req, res) => {
    res.render('taskForm', { projectId: req.params.projectId });
});

// Guardar nueva tarea
router.post('/:projectId/tasks/new', async function (req, res) {
    const projectId = req.params.projectId;
    const API_URL = req.app.locals.config.API_URL_PROJECTS_TASKS;

    const newTask = {
        title: req.body.title,
        description: req.body.description
    };

    try {
        const response = await fetch(`${API_URL}/${projectId}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newTask)
        });

        if (!response.ok) throw new Error(`Error al agregar tarea: ${response.statusText}`);

        res.redirect(`/projects/${projectId}/tasks`);
    } catch (error) {
        console.error('Error al guardar tarea:', error);
        res.status(500).send('Error al guardar tarea');
    }
});

module.exports = router;
