# TuringTest

El controlador izquierdo puede usarse para desplazarse con el joystick.
El controlador derecho permite girar sobre si mismo inclinando el joysitck hacia los lados o activar el modo teletransporte con seleccion de orientacion. Para ello hay que mantener pulsado el joystick hacia adelante y luego se puede elegir la direccion de orientacion deseada.

Para interactuar con los objetos y añadirlos al inventario, apuntar hacia ellos y pulsar el grip del controlador.

El inventario está diseñado para ajustar su tamaño dinámicamente al número de objetos que hay en él, de forma que sea fácilmente escalable en función del tamaño máximo de inventario.

Una vez hay un objeto en el inventario que aparece encima de la cabeza del usuario, si apunta hacia él y pulsa el grip del mando aparecerán o desapareceran si ya estan visibles los botones de interacción para usarlo o deshacerse de él.

Cuando la pocion sea usada sumara 20 puntos de vida a la vida del dummy.

Cuando las balas sean usadas se añadirán al contador de disparos disponibles que puede ser consultado en el icono de la esquina inferior derecha.
Si se coge la pistola con el grip del mando y mientras se mantiene pulsada se aprieta el gatillo se producirá un disparo siempre y cuando haya balas disponibles.
Si el disparo impacta en el dummy (el rayo rojizo) perdera 15 puntos de vida.

Cuando todos los objetos de un tipo han sido usados o borrados, son sustituidos por un objeto de tipo basura que puede ser configurable para cada tipo de elemento. 

Mientras tiene basura de un tipo de objeto en el inventario no puede recoger otro objeto de ese mismo tipo.
