# Micro Forest — Architecture Document
*Versión: Borrador v0.1 — En revisión*

## 1. Propósito de este documento

Este documento define cómo está organizado el código de Micro Forest y por 
qué. No describe qué es el juego (eso vive en `01_GDD.md`) — describe cómo 
se construye. Cualquier decisión estructural nueva (nuevos managers, 
cambios de patrón) debería reflejarse aquí y, si reemplaza algo ya 
decidido, registrarse también en `04_DesignDecisions.md`.

## 2. Comunicación entre sistemas

Los sistemas de gameplay se comunican mediante **eventos de C# (delegates/
Actions)**, no mediante referencias directas entre scripts ni 
ScriptableObject Events.

**Por qué:** permite que, por ejemplo, el sistema de corte de vegetación 
"avise" que se generó un Bug Token sin necesitar conocer directamente al 
sistema de economía. Mantiene los sistemas desacoplados sin añadir la 
complejidad de patrones más avanzados (Service Locator, DI), innecesarios 
para el tamaño de este proyecto.

## 3. Organización de carpetas (`Assets/Scripts/`)
Scripts/
Player/         → Movimiento, input, corte de vegetación de Micro
Economy/        → Bug Tokens, conversión de insectos, inventario
Progression/    → Skill Tree, mejoras del machete
World/          → Vegetación, obstáculos, generación/reset del bosque
Core/           → GameManager, estados del juego, cosas transversales

**Por qué:** organizada por sistema/responsabilidad, reflejando 
directamente las secciones del GDD. Facilita ubicar código relevante sin 
adivinar, y probablemente cada carpeta mapea a un sprint del Roadmap.

## 4. Estado global y Managers

En vez de un único `GameManager` que controle todo, el estado se divide 
en managers pequeños y especializados, cada uno Singleton dentro de su 
propio dominio:

- **`GameManager`** (`Core/`) → estado general del juego (en la run, en 
  casa, durmiendo, en menú). No contiene lógica de economía ni progresión.
- **`EconomyManager`** (`Economy/`) → dueño de los Bug Tokens: cantidad 
  actual, sumar, gastar.
- **`ProgressionManager`** (`Progression/`) → dueño del Skill Tree y las 
  mejoras del machete.

**Por qué:** evita el antipatrón de "God Object" (una clase que sabe y 
hace demasiado). Cada script consulta únicamente al manager relevante 
para su necesidad, no a un punto central que lo sepa todo.

## 5. Persistencia de datos (Save System)

El progreso del jugador (Bug Tokens, mejoras del Skill Tree, nivel del 
machete) se guarda en un **archivo JSON propio**, mediante una clase 
`SaveData` serializable, escrita a disco con las utilidades estándar de 
.NET/Unity (`JsonUtility`).

**Por qué:** más estructurado y depurable que `PlayerPrefs`, sin la 
complejidad innecesaria de un sistema de guardado encriptado o versionado, 
que no aporta valor en esta etapa del proyecto.

## 6. Convenciones de código

- **Namespace raíz:** `MicroForest`, con sub-namespaces por carpeta 
  (ej. `MicroForest.Player`, `MicroForest.Economy`).
- **Clases:** PascalCase (ej. `EconomyManager`).
- **Variables privadas:** camelCase con prefijo `_` (ej. `_bugTokenCount`).
- **Commits:** prefijos `feat:`, `fix:`, `docs:`, `refactor:`, `chore:` 
  (ya en uso desde Foundation).

## 7. Decisiones pendientes

Estas decisiones se resolverán cuando el sprint correspondiente las 
necesite, no antes (para evitar diseñar arquitectura que aún no aplica):

- Estructura interna del Skill Tree (¿ScriptableObjects por mejora? 
  ¿una tabla de datos?).
- Sistema de generación/reset del bosque (¿procedural o diseño manual 
  por zona?).
- Estructura de datos para el `SaveData` (campos exactos, versión inicial).