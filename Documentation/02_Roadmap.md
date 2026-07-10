# Micro Forest — Roadmap
*Versión: Borrador v0.1 — En revisión*

## 1. Propósito de este documento

Este documento traduce el GDD y la Arquitectura en una secuencia concreta 
de sprints hacia Micro Forest v1.0. Las estimaciones de tiempo son 
aproximadas, no compromisos rígidos — se ajustan si un sprint toma más 
o menos de lo esperado. Cada sprint se cierra actualizando este documento 
y registrando avances en `06_DevLog.md`.

## 2. Contexto de tiempo disponible

- **Semanas de receso** (~6 semanas): varias horas disponibles casi a 
  diario. Ritmo intensivo — ideal para los sprints con mayor curva de 
  aprendizaje.
- **Semanas de semestre**: varias horas entre semana. Ritmo moderado — 
  mejor para sprints de pulido o iterativos, que se benefician de trabajo 
  más espaciado.

## 3. Sprints hacia v1.0

### Sprint 1 — Movimiento y corte básico
**Objetivo:** Micro se mueve por el mapa horizontal y puede cortar 
vegetación, generando insectos.
**Entregable:** Prototipo jugable sin arte final — un cubo o placeholder 
moviéndose y "cortando" cajas que representan vegetación.
**Estimado:** 1.5–2 semanas (ritmo de receso).

### Sprint 2 — Economía mínima (ajustado)
**Objetivo:** Los insectos recolectados se cuentan en un "bolsillo" 
temporal durante la run. La conversión a Bug Tokens ocurre en el 
Sprint 3, al volver a casa.
**Entregable:** Sistema de recolección con imán + contador de bichos 
en pantalla (aún no es la moneda permanente).

### Sprint 3 — Ciclo casa-bosque
**Objetivo:** El jugador puede volver a casa, "dormir", y el bosque se 
resetea para la siguiente run. Incluye el primer guardado real vía JSON.
**Entregable:** Loop completo jugable de principio a fin (sin mejoras 
todavía) — salir, cortar, volver, dormir, repetir.
**Estimado:** 1.5–2 semanas (ritmo de receso).

### Sprint 4 — Progresión
**Objetivo:** Skill Tree funcional; el jugador compra mejoras con Bug 
Tokens y estas persisten entre runs (gracias al guardado del Sprint 3).
**Entregable:** Al menos 2-3 mejoras reales implementadas (ej. daño, 
velocidad de movimiento) con efecto medible en el gameplay.
**Estimado:** 2 semanas (puede cruzar la transición receso → semestre).

### Sprint 5 — Bloqueos y zonas
**Objetivo:** Obstáculos que requieren nivel de machete específico; 
superar uno desbloquea una nueva zona del bosque.
**Entregable:** Al menos 2 zonas distintas conectadas por un bloqueo.
**Estimado:** 2–3 semanas (ritmo de semestre).

### Sprint 6 — Arte y pulido cozy
**Objetivo:** Reemplazar placeholders por arte final; ambientación, 
animaciones básicas, sonido.
**Entregable:** El juego se ve y se siente como Micro Forest, no como 
un prototipo con cubos.
**Estimado:** 3–4 semanas (ritmo de semestre, iterativo).

### Sprint 7 — Final del juego
**Objetivo:** Castillo, encuentro de rescate, cierre narrativo.
**Entregable:** El jugador puede completar el juego de principio a fin.
**Estimado:** 1–2 semanas (ritmo de semestre).

## 4. Fuera de este roadmap

Balance numérico fino (cuánto daño exacto, cuántos tokens por obstáculo, 
etc.) no tiene sprint propio — se ajusta de forma continua dentro de cada 
sprint relevante, no como una fase separada.