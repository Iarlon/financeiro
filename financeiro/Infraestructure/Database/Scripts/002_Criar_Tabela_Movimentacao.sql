CREATE TABLE movimentacao (
    id BIGSERIAL PRIMARY KEY,
    usuario_id INT NOT NULL,

    categoria INT NOT NULL,
    tipo INT NOT NULL,

    valor NUMERIC(18,2) NOT NULL,
    data TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

    descricao VARCHAR(255),
    tag VARCHAR(100),

    CONSTRAINT ck_movimentacao_valor
        CHECK (valor > 0),
);
