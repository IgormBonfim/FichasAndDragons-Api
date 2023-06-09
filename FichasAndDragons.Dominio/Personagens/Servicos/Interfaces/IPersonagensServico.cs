﻿using FichasAndDragons.Dominio.Personagens.Entidades;
using FichasAndDragons.Dominio.Personagens.Servicos.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichasAndDragons.Dominio.Personagens.Servicos.Interfaces
{
    public interface IPersonagensServico
    {
        Personagem Validar(string id);
        Personagem Instanciar(PersonagensInstanciarComando instanciarComando);
        Personagem Inserir(Personagem personagem);
        Personagem Editar(Personagem personagemEditar, string id);
        bool MudarInspiracao(string id);
    }
}
