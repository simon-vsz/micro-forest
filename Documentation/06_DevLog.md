## 2026-07-09 — Ajuste de Fixed Timestep

Se detectó stutter en el movimiento de Micro al sostenerlo por varios 
segundos. Causa: desajuste entre el Fixed Timestep del proyecto y la 
frecuencia de refresco del monitor. Resuelto ajustando Fixed Timestep 
en Project Settings → Time.

## 2026-07-10 — Sprint 2: Sistema de recolección de insectos

Implementado el sistema completo de corte → salto físico → aterrizaje 
→ atracción magnética → recolección, con contador en pantalla (TextMeshPro).

Aprendizajes técnicos clave:
- Separación de capas de física (Layer Collision Matrix) para evitar 
  colisiones físicas no deseadas entre el jugador y objetos coleccionables, 
  sin romper la detección de triggers.
- Uso de `isKinematic` para desactivar física de un Rigidbody una vez que 
  su movimiento pasa a ser controlado manualmente por código.
- Ajuste de relación de aspecto de cámara (16:9) vía `Camera.rect`.

## 2026-07-11 — Sprint 3: Ciclo casa-bosque completo

Implementado el loop completo: interacción con la casa (botón compartido 
con Attack), conversión de bichos a Bug Tokens según rareza, guardado 
persistente vía JSON (Application.persistentDataPath), reset del bosque, 
y transición de pantalla negra al dormir.

Aprendizajes técnicos clave:
- FindGameObjectsWithTag no encuentra objetos desactivados — se resolvió 
  con un registro estático propio (lista de instancias) en Vegetation.
- Patrón de "recurso temporal → conversión a moneda permanente" separado 
  en dos sistemas distintos (PocketInventory vs EconomyManager), 
  comunicados por eventos.
- Uso de Coroutines para transiciones de fade (interpolación de alpha 
  con Mathf.Lerp).


## 2026-07-12 — Sprint 4: Sistema de progresión y tienda

Implementado ProgressionManager con niveles de mejora persistentes 
(Velocidad de Movimiento, Velocidad de Ataque), menú de tienda accesible 
al interactuar con la casa, navegación completa por teclado (sin mouse).

Aprendizajes técnicos clave:
- Cambio de Input Action Maps (Player/UI) para separar contextos de 
  control, evitando que el jugador se mueva con el menú abierto.
- Legacy Input Manager (Project Settings) es un sistema completamente 
  separado del nuevo Input System — no comparten configuración.
- El EventSystem puede tener su propio "Actions Asset" desconectado 
  del proyecto general; hay que verificarlo explícitamente.
- Selección de UI perdida en el mismo frame al establecerse durante 
  el procesamiento de un evento de input — se resuelve retrasando la 
  selección un frame con una Coroutine (yield return null).
- Herramientas de Editor-only (carpeta Editor/, [MenuItem]) para 
  utilidades de testing que no deben incluirse en builds finales.


