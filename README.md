# TP1 - SHMUP

Shoot 'em up de scroll horizontal hecho en Unity para el Trabajo Práctico 1 de **Programación 1**.

Controlás a un personaje que avanza volando de izquierda a derecha por tres niveles de terror. Esquivá a los monstruos y sus disparos, juntá power-ups y sumá la mayor cantidad de puntos posible.

## Cómo jugar

### Controles

| Acción | Tecla |
|---|---|
| Moverse | Flechas o `W` `A` `S` `D` |
| Disparar | `Z` (mantener apretado para disparo continuo) |
| Pausa | `Esc` |

### Objetivo

- Los enemigos entran por la **derecha** de la pantalla.
- Un nivel termina cuando ya aparecieron todos sus enemigos y no queda ninguno en pantalla. Después de unos segundos empieza el siguiente.
- Si un enemigo o una bala enemiga te toca, **perdés** (salvo que tengas escudo).
- Los enemigos que se escapan por la izquierda no te dañan, pero tampoco dan puntos.

### Niveles

| Nivel | Qué esperar |
|---|---|
| **Nivel 1** | Monstruos rápidos que embisten en grupo y brujas que disparan en diagonal. Sirve para aprender a esquivar. |
| **Nivel 2** | Enemigos más lentos pero con mucho poder de fuego: ojos, momias, vampiros y las cabezas gigantes. A mitad de nivel aparece el power-up de armas extra. |
| **Nivel 3** | Supervivencia. Aguantá todo lo que puedas: llegar hasta acá ya cuenta como victoria. |

### Power-ups

| Power-up | Efecto |
|---|---|
| **Escudo** | Absorbe un golpe. Al romperse, quedás invencible por un instante (el personaje parpadea). |
| **Armas extra** | Agrega dos cañones en abanico. Se mantienen hasta el final de la partida. |

### Puntaje

| Enemigo | Puntos |
|---|---|
| Diablo, Frankenstein | 20 |
| Bruja, Ojo, Momia, Vampiro, Cabeza | 45 |

El puntaje se muestra arriba a la izquierda y se conserva entre niveles.

### Fin de la partida

- **GAME OVER**: si te derrotan en el nivel 1 o 2. Podés **reintentar** desde el nivel 1 o volver al **menú**.
- **¡VICTORIA!**: si sobrevivís al nivel 3.
- **¡AGUANTASTE!**: si caés en el nivel 3. También cuenta como victoria y muestra tu puntaje final.

### Menú de pausa

Con `Esc` el juego se congela. Desde ahí podés **continuar** (también con `Esc`) o volver al **menú principal**.

## Cómo abrir el proyecto

1. Instalar **Unity 6000.3.10f1** (Unity 6) desde Unity Hub.
2. En Unity Hub: **Add → Add project from disk** y elegir esta carpeta.
3. Abrir la escena `Assets/Project/Scenes/Menu.unity` y darle **Play**.

## Estructura del proyecto

```
Assets/Project/
├── Art/          Sprites (fondos, jugador, enemigos, power-ups, proyectiles)
├── Audio/        Música de fondo y efectos de sonido
├── Materials/    Materiales de los fondos con scroll infinito
├── Prefabs/      Enemigos, proyectiles, power-ups, Level y AudioManager
├── Scenes/       Menu, Level1, Level2, Level3
└── Scripts/
    ├── Animation/    Animación de sprites en loop
    ├── Background/   Scroll infinito del fondo
    ├── Enemies/      Movimiento, daño e identidad de los enemigos
    ├── Managers/     Level (niveles, score, pausa), EnemySpawner y AudioManager
    ├── Player/       Movimiento, disparo, escudo y animación del jugador
    ├── PowerUp/      Tipos de power-up
    ├── Projectiles/  Balas
    ├── UI/           Menú principal
    └── Weapons/      Armas (jugador y enemigos)
```

Los enemigos de cada nivel se configuran en el componente **EnemySpawner** de cada escena: cada fila indica qué aparece, en qué segundo, a qué altura de la pantalla y cuántas veces.

## Créditos

- **Desarrollo:** Matias Leandro Sanchez
- **Arte:** [Spooky Shmup](https://phantomcooper.itch.io/spooky-shmup) de Phantom Cooper
