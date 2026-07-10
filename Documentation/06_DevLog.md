## 2026-07-09 — Ajuste de Fixed Timestep

Se detectó stutter en el movimiento de Micro al sostenerlo por varios 
segundos. Causa: desajuste entre el Fixed Timestep del proyecto y la 
frecuencia de refresco del monitor. Resuelto ajustando Fixed Timestep 
en Project Settings → Time.