﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public class Evento {
        private string nome;
        public string Nome { get { return nome; } set { this.nome = value; } }
        private EstadoDoEvento estadoEvento;
        public EstadoDoEvento Estado { get { return estadoEvento; } set { estadoEvento = value; } }
        public List<Atividade> ListaDeAtividades = new List<Atividade>();

        public Evento() {
            Estado = EstadoDoEvento.Aberto;
            ListaDeAtividades = new List<Atividade>();
        }
        public void AdicionarAtividade(Atividade atividade) {
            if (!ListaDeAtividades.Contains(atividade)) {
                ListaDeAtividades.Add(atividade);
            } else {
                throw new Exception("Atividade repetida");
            }
        }
        public void RemoverAtividade(Atividade atividade) {
            if (ListaDeAtividades.Contains(atividade)) {
                ListaDeAtividades.Remove(atividade);
            } else {
                throw new Exception("Atividade nao existe");
            }


        }
    }
}
