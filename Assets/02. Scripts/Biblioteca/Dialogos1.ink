INCLUDE VariablesGlobales.ink

{decision == "": -> NPC02 | ->DecisionSi}

=== NPC02 ===
Ey Como estas?
Vi que el NPC01 te pidio ayuda para algo. Aceptaste?
    * [Si]
    -> Si
    * [De hecho no]
    -> No
-> END

=== Si ===
~ decision = "Si"
Buah, buena suerte entonces
-> END

=== No ===
Menos mal, esa aventura es muy peligrosa
-> END

=== DecisionSi ===
Pues tu decidiste aceptar la mision...
No puedo decirte nada
-> END