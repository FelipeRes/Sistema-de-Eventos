﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.Modelo.Notificacoes {
    public interface Notificavel {
        int Id { get; set; }
        void Atualizar(string message);
    }
}
