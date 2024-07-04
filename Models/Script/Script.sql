CREATE TABLE Veiculos (
    id INT PRIMARY KEY IDENTITY,
    placa VARCHAR(20) NOT NULL,
    modelo VARCHAR(100) NOT NULL,
    ano INT NOT NULL
);

CREATE TABLE ItensInspecao (
    id INT PRIMARY KEY IDENTITY,
    descricao VARCHAR(200) NOT NULL
);

CREATE TABLE Usuarios (
    id INT PRIMARY KEY IDENTITY,
    nome VARCHAR(100) NOT NULL,
    tipo VARCHAR(50) NOT NULL -- "executor" ou "supervisor"
);


CREATE TABLE Checklists (
    id INT PRIMARY KEY IDENTITY,
    veiculo_id INT NOT NULL,
    usuario_executor_id INT NOT NULL,
    data_inicio DATETIME NOT NULL,
    data_fim DATETIME,
    aprovado BIT,
    usuario_supervisor_id INT,
    FOREIGN KEY (veiculo_id) REFERENCES Veiculos(id),
    FOREIGN KEY (usuario_executor_id) REFERENCES Usuarios(id),
    FOREIGN KEY (usuario_supervisor_id) REFERENCES Usuarios(id)
);

CREATE TABLE ChecklistItens (
    id INT PRIMARY KEY IDENTITY,
    checklist_id INT NOT NULL,
    item_inspecao_id INT NOT NULL,
    conforme BIT,
    observacao VARCHAR(500),
    FOREIGN KEY (checklist_id) REFERENCES Checklists(id),
    FOREIGN KEY (item_inspecao_id) REFERENCES ItensInspecao(id)
);
