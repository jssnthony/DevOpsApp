'use strict';
var express = require('express');
var router = express.Router();

router.get('/', async function (req, res) {
    try {
        const response = await fetch('https://localhost:7101/Project', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`Error en la petición: ${response.statusText}`);
        }

        const data = await response.json();
        res.render('projects', { title: 'Projects', projects: data });
    } catch (error) {
        console.error('Error al obtener proyectos:', error);
        res.status(500).send('Error al obtener proyectos');
    }
});
module.exports = router;
