# Micro Forest — Game Design Document
*Versión: Borrador v0.1 — En revisión*

## 1. Visión del juego

Micro Forest es un roguelite cozy de progresión incremental en el que Micro, una 
pequeña conejita armada con un machete, se adentra cada mañana en un bosque 
encantado que vuelve a crecer cada noche, avanzando un poco más lejos en cada 
intento hasta rescatar a su esposo, secuestrado por una bruja.

## 2. Historia

El esposo de Micro fue secuestrado por una bruja, que lanzó un hechizo sobre 
un bosque encantado para proteger su castillo. Cada noche, el bosque regresa 
a su estado original. Cada mañana, Micro entra de nuevo, decidida a avanzar 
un poco más que el día anterior, hasta alcanzar el castillo y rescatarlo.

El espíritu del bosque (una mantis), fue expulsado debido a la maldicion de la
bruja, y le pide a Micro que le ayude a rescatar a los bichos del bosque; los bichos 
que Micro recolecta se convierten en Bug Tokens al volver a casa.

*(Esta es la premisa mínima necesaria para justificar el loop. No se expande 
más en la v1.0 — diálogos, cinemáticas o lore adicional quedan en Backlog 
salvo que se decida lo contrario explícitamente).*

## 3. Core Gameplay Loop
Salir de casa → Cortar vegetación → Conseguir Bug Tokens → Volver a casa
→ Dormir → Comprar mejoras permanentes → El bosque vuelve a crecer
→ Intentar llegar más lejos

Este loop es el corazón del juego y **no se modifica** sin pasar primero por 
`04_DesignDecisions.md`. Cualquier mecánica nueva debe justificarse en 
relación a este loop, no añadirse en paralelo.

## 4. Estructura de una Run

- Duración objetivo: 1–3 minutos.
- El jugador decide voluntariamente cuándo volver a casa; no hay límite de 
  tiempo forzado ni mecánica de energía/hambre.
- El incentivo para volver es puramente de progresión: vender Bug Tokens, 
  dormir, comprar mejoras.
- No hay penalización por run "fallida" — el concepto de fallo no existe 
  como tal, solo el de "qué tan lejos llegué esta vez".

## 5. Economía

- Única moneda: **Bug Tokens**.
- Se obtienen al romper vegetación, que libera insectos.
- Insectos comunes → Bug Tokens estándar. Insectos raros → más Bug Tokens.
- No hay conversión entre monedas ni sistemas económicos secundarios en v1.0.
- Micro Va al espiritu del bosque que está al lado de su casa y le da los bichos
  que recoge a cambio de dinero. 
- Los bug tokens se usan como material para fabricar las mejoras cuando micro se va
  a dormir


## 6. Progresión (Macro Powers - Skill Tree)

- Progresión 100% permanente entre runs (no hay pérdida de mejoras).
- Las mejoras se compran en casa, entre runs, con Bug Tokens.
- El Skill Tree (aún sin balancear) contempla las ramas de: Daño, Velocidad 
  de ataque, Área de golpe, Velocidad de movimiento, Suerte, Golpe crítico, 
  Capacidad de Bug Tokens.
- El machete progresa por separado: cambios de material de hoja aumentan 
  daño y desbloquean la capacidad de superar obstáculos específicos.
- Tugui, el esposo de micro, le deja cartas a medida que avanza en el 
  bosque. 

## 7. Mundo y Bloqueos

- Mapa horizontal, un solo eje de avance (izquierda → derecha).
- Vista superior en 3/4, cámara fija (sin cámara libre ni rotaciones).
- El avance está limitado por obstáculos que requieren un nivel de machete 
  específico para superarse.
- Superar un obstáculo desbloquea la siguiente zona del bosque.
- El extremo derecho del mapa es el castillo de la bruja — el destino final 
  del juego.
- Micro rescata a Yolki (un huevito mascota) que estaba perdido en el bosque. 
  Yolki acompaña a Micro de forma puramente estética, sin efecto en las mecánicas de 
  juego.

## 8. Condición de finalización

Micro Forest v1.0 tiene un final formal: al llegar al castillo y rescatar 
al esposo, el juego se considera completado. El contenido exacto de ese 
encuentro final (qué ocurre, cómo se representa) **no se diseña en este 
documento** — se resolverá cuando lleguemos al diseño de la zona final. 
Aquí solo se deja establecido que el final existe y es narrativo/estructural, 
no un "loop infinito sin cierre".

## 9. Dirección de arte

- Tono: cozy, cute, relajante — incluso con progresión incremental de por medio.
- Referencia principal: Animal Crossing.
- Protagonista: Micro, una conejita con un machete.
- El bosque debe sentirse acogedor, no amenazante, a pesar de ser el 
  "obstáculo" central del juego.

## 10. Fuera de alcance en v1.0 (ver `05_Backlog.md` para detalle)

Explícitamente **no** forman parte de la v1.0:
- Sistema de hambre o energía.
- Durabilidad o afilado del machete.
- Sistema complejo de ciclo noche/día más allá del "reset" del bosque.
- Campamentos.
- Múltiples biomas.
- Árboles gigantes / crafting.
- Múltiples tipos de moneda.
- Mover la casa (bajo evaluación para versiones futuras).