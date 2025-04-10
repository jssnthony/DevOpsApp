'use strict';
var express = require('express');
var router = express.Router();

process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0'; // Deshabilitar validación SSL

router.get('/', async function (req, res) {
    try {
        const API_URL_PROJECTS = req.app.locals.config.API_URL_PROJECTS; // Obtener la URL desde app.js
        
        const response = await fetch(`${API_URL_PROJECTS}` , {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`Error en la petición: ${response.statusText}`);
        }

        const data = await response.json();
        console.log(data);
        res.render('projects', { title: 'Projects', projects: data });
    } catch (error) {
        console.error('Error al obtener proyectos:', error);
        res.status(500).send('Error al obtener proyectos');
    }
});

module.exports = router;
