# Backlog — Micro Forest

Ideas y mecánicas que no forman parte de la v1.0. Aquí viven sin presionar 
el alcance del juego actual. Promover algo de aquí al GDD requiere una 
decisión explícita registrada en 04_DesignDecisions.md.

---

## Progresión / Mundo — Mover la casa

**Descripción:** La casa de Micro podría reubicarse más adelante en el 
mapa a medida que se desbloquean zonas, acortando el trayecto de cada run.

**Por qué no está en v1.0:** Añade complejidad de diseño de nivel y lógica 
de transición que no es esencial para un loop pulido y terminado.

**Estado:** Backlog

---

## Mecánicas — Sistema de hambre / energía

**Descripción:** El jugador tendría un recurso que se agota durante la run, 
forzando el regreso a casa.

**Por qué no está en v1.0:** El regreso ya está incentivado naturalmente 
por la economía (vender tokens, comprar mejoras). Un sistema de hambre 
añadiría fricción sin aportar al loop central.

**Estado:** Backlog

---

## Mecánicas — Durabilidad y afilado del machete

**Descripción:** El machete se desgastaría con el uso y requeriría 
mantenimiento entre runs.

**Por qué no está en v1.0:** Introduce un sistema de mantenimiento 
paralelo a la progresión permanente, compitiendo por atención del 
jugador sin sumar al objetivo del loop.

**Estado:** Backlog

---

## Contenido — Campamentos

**Descripción:** Puntos intermedios dentro de una run donde el jugador 
podría descansar o interactuar antes de continuar.

**Por qué no está en v1.0:** Las runs ya son cortas (1-3 min); un sistema 
de campamentos añade una capa de decisión intermedia innecesaria para 
ese alcance.

**Estado:** Backlog

---

## Contenido — Múltiples biomas

**Descripción:** El bosque tendría zonas visual y mecánicamente distintas 
(ej. bosque nevado, pantano, etc.).

**Por qué no está en v1.0:** Multiplica el trabajo de arte y diseño de 
nivel sin ser necesario para un loop pulido de un solo bioma bien hecho.

**Estado:** Backlog

---

## Contenido — Árboles gigantes / crafting

**Descripción:** Sistema de recolección de recursos y crafteo de objetos 
o mejoras a partir de materiales obtenidos en el bosque.

**Por qué no está en v1.0:** La economía de v1.0 es deliberadamente 
simple (una sola moneda). Un sistema de crafting introduce múltiples 
recursos, contradiciendo esa decisión.

**Estado:** Backlog

---

## Economía — Múltiples tipos de moneda

**Descripción:** Monedas adicionales (ej. oro, gemas raras) con distintos 
usos.

**Por qué no está en v1.0:** Se decidió explícitamente simplificar a una 
sola moneda (Bug Tokens) para mantener la economía legible y fácil de 
balancear.

**Estado:** Descartado para v1.0 (revisar solo si v2.0 lo justifica)

---

## Mundo / Arte — Criaturas nocturnas

**Descripción:** Criaturas o insectos distintos que aparecen 
específicamente durante la noche (el ciclo día/noche base ya es parte 
de la v1.0 desde el Sprint 5 — ver 04_DesignDecisions.md).

**Por qué no está en v1.0:** Es contenido adicional (nuevos tipos de 
insectos/criaturas) sobre un sistema que ya existe, no la base del 
ciclo día/noche en sí.

**Estado:** Backlog

---

## Progresión — Construcción estilo Animal Crossing

**Descripción:** Sistema de construcción/decoración de la casa o del 
entorno, desbloqueado progresivamente a medida que se recolectan bichos.

**Por qué no está en v1.0:** Introduce un sistema de progresión paralelo 
al Skill Tree y a la economía ya definidos, con su propia lógica de 
desbloqueo y necesidades de arte. Compite con el foco del loop principal 
en vez de reforzarlo.

**Estado:** Backlog

---

## Mundo / Mecánicas — Expansión vertical y salto (torres)

**Descripción:** Posibilidad de expandir el mapa más allá del eje 
horizontal —por ejemplo, torres que requieran saltar para subir, o 
zonas laterales adicionales al camino principal.

**Por qué no está en v1.0:** El diseño actual del mundo es estrictamente 
horizontal (izquierda → derecha). Añadir verticalidad o mecánica de 
salto expande el alcance de nivel, física y diseño de obstáculos más 
allá de lo necesario para un v1.0 pulido. La arquitectura de movimiento 
(Rigidbody con gravedad activa) ya deja la puerta abierta para esto sin 
costo adicional ahora.

**Estado:** Backlog

---

## Nota de diseño pendiente — Sprint 5

Micro debería poder caminar A TRAVÉS del pasto sin cortarlo (no bloquea 
el paso), con una ligera reducción de velocidad al atravesarlo — refuerza 
la sensación de "vegetación real" sin fricción excesiva. Diferente del 
corte, que sigue requiriendo el ataque explícito.