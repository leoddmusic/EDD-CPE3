using System;
using System.Collections.Generic;

class TorneoFutbol {
    private Dictionary<string, HashSet<string>> equipos;

    public TorneoFutbol() {
        equipos = new Dictionary<string, HashSet<string>>();
    }

    public void RegistrarEquipo(string nombreEquipo) {
        if (!equipos.ContainsKey(nombreEquipo)) {
            equipos[nombreEquipo] = new HashSet<string>();
            Console.WriteLine($"✅ Equipo '{nombreEquipo}' registrado.");
        } else {
            Console.WriteLine($"⚠️ El equipo '{nombreEquipo}' ya está registrado.");
        }
    }

    public void AgregarJugador(string nombreEquipo, string nombreJugador) {
        if (equipos.ContainsKey(nombreEquipo)) {
            if (equipos[nombreEquipo].Add(nombreJugador)) {
                Console.WriteLine($"👤 Jugador '{nombreJugador}' agregado al equipo '{nombreEquipo}'.");
            } else {
                Console.WriteLine($"⚠️ El jugador '{nombreJugador}' ya está en el equipo '{nombreEquipo}'.");
            }
        } else {
            Console.WriteLine($"❌ El equipo '{nombreEquipo}' no existe. Regístrelo primero.");
        }
    }

    public void MostrarEquiposYJugadores() {
        Console.WriteLine("\n📋 Lista de Equipos y sus Jugadores:");
        foreach (var equipo in equipos) {
            Console.WriteLine($"🏆 {equipo.Key}: {string.Join(", ", equipo.Value)}");
        }
    }

    public void BuscarJugador(string nombreJugador) {
        Console.WriteLine($"\n🔍 Buscando al jugador '{nombreJugador}'...");
        foreach (var equipo in equipos) {
            if (equipo.Value.Contains(nombreJugador)) {
                Console.WriteLine($"✅ El jugador '{nombreJugador}' pertenece al equipo '{equipo.Key}'.");
                return;
            }
        }
        Console.WriteLine($"❌ El jugador '{nombreJugador}' no está registrado en ningún equipo.");
    }
}

class Program {
    static void Main() {
        TorneoFutbol torneo = new TorneoFutbol();

        torneo.RegistrarEquipo("Los Guerreros");
        torneo.RegistrarEquipo("Los Titanes");

        torneo.AgregarJugador("Los Guerreros", "Juan Pérez");
        torneo.AgregarJugador("Los Guerreros", "Carlos López");
        torneo.AgregarJugador("Los Titanes", "Mario Sánchez");
        torneo.AgregarJugador("Los Titanes", "Luis Gómez");

        torneo.MostrarEquiposYJugadores();

        torneo.BuscarJugador("Carlos López");
        torneo.BuscarJugador("Pedro Ramírez");
    }
}
