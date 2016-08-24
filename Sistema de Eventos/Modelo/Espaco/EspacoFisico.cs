﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos {
    public abstract class EspacoFisico {

        protected int capacidade;
        protected string nome;

        abstract public string Nome { get; }
        abstract public int Capacidade { get; }

        private GerenciaAtividade listaDeAtividades;

        public void AdicionarAtividade(Atividade atividade) {
            listaDeAtividades.AdicionarAtividade(atividade);
        }
        public void RemoverAtividade(Atividade atividade) {
            listaDeAtividades.RemoverAtividade(atividade);
        }
    }
}
