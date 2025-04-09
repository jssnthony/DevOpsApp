'use strict';
const express = require('express');
const router = express.Router();

process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';

router.get('/:projectId', async function (req, res) {
    const projectId = req.params.projectId;
    res.render('projectsTasksInsert', { projectId });
});

router.post('/:projectId', async function (req, res) {
    const API_URL = req.app.locals.config.API_URL_PROJECTS_TASKS;
    const projectId = req.params.projectId;
    const { title, description, status } = req.body;

    try {
        const response = await fetch(`${API_URL}/${projectId}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, description, status })
        });

        if (!response.ok) {
            throw new Error(`Error al insertar la tarea: ${response.statusText}`);
        }

        res.redirect(`/projectsTasks/${projectId}`);
    } catch (error) {
        console.error('Error al insertar tarea:', error.message);
        res.status(500).send('Error al insertar tarea');
    }
});

module.exports = router;
