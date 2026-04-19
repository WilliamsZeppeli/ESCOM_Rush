# ESCOM Rush 🕹️

**ESCOM Rush** es un videojuego tipo **Endless Runner** desarrollado en **Unity**, inspirado en el entorno de la Escuela Superior de Cómputo (ESCOM - IPN).

El jugador deberá avanzar esquivando obstáculos dentro de escenarios ambientados en la escuela, acumulando puntos y sobreviviendo el mayor tiempo posible en el modo **Infinito**.

---

## 📌 Descripción del proyecto

El concepto principal de ESCOM Rush es combinar la jugabilidad clásica de los runners con una temática universitaria, incorporando referencias locales de ESCOM en personajes, escenarios y obstáculos.

El proyecto contempla:

* 🎮 Modo **Infinito** con dificultad progresiva y Modo **Historia**
* 🏫 Escenarios inspirados en instalaciones de ESCOM.
* ⚡ Obstáculos dinámicos.
* 📈 Sistema de puntaje en tiempo real.
* ⏸️ Sistema de pausa y reanudación.
* 🎛️ Menú principal con opciones configurables.
* 💻 Interfaz moderna utilizando **Unity UI Toolkit**.

---

## 🕹️ Mecánicas de juego

### Movimiento del jugador

* Salto mediante tecla **Espacio** o clic/touch.
* Movimiento horizontal izquierda/derecha.
* Restricción dentro de los límites del mapa. 

### Obstáculos

* Generación automática aleatoria.
* Movimiento continuo hacia el jugador.
* Eliminación automática fuera de pantalla para optimización.  

### Derrota

* Si el jugador colisiona con un obstáculo:
  * El personaje retrocede y puede:
    * Seguir adelante y ser más rápido que el perseguidor.
    * Perder si sale de la pantalla.
  * Se reinicia automáticamente la escena actual.  

---

## 🖥️ Interfaz de usuario

El proyecto cuenta con:

### Menú Principal

* Modo de Juego
* Opciones
* Salir

### Modo de Juego

* Modo Infinito
* Modo Historia

### Opciones

* Volumen general
* Música
* Efectos de sonido

### Durante la partida

* Puntaje en tiempo real
* Botón de pausa
* Menú de pausa
* Regresar al menú principal  

---

## 🧱 Estructura del proyecto

```bash
Assets/
├── Scripts/
│   ├── ControladorJuego.cs
│   ├── GameManager.cs
│   ├── GeneradorObstaculos.cs
│   ├── JugadorControlador.cs
│   ├── Menu.cs
│   ├── ObstaculoMovimiento.cs
│   └── UIManager.cs
```

---

## ⚙️ Tecnologías utilizadas

* **Unity Engine**
* **C#**
* **Unity UI Toolkit**
* **Physics2D**
* **Scene Management**

---

## 🚀 Cómo ejecutar el proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/WilliamsZeppeli/ESCOM_Rush.git
```

2. Abrir el proyecto en Unity Hub.

3. Cargar la escena principal.

4. Ejecutar con **Play**.

---

## 👨‍💻 Equipo de desarrollo

* González Rodríguez Zoe
* Quintanar Bravo Jacqueline Williams
* Segura Vázquez Brandon
* Vázquez Hernández Michel 

---

## 📜 Licencia

Proyecto académico desarrollado con fines educativos.
