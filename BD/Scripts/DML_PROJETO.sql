Use Projetos;

INSERT INTO TipoUsuario(nome)
VALUES					('Especialista')
					    ,('Colaborador')
                        ,('Adm');
                        
INSERT INTO Setor(nome)
VALUES				('Suporte')
					,('Manutenção')
                    ,('Limpeza');
                    
INSERT INTO Usuario(IdSetor, IdTipoUsuario, nome, email, senha, cpf, telefone)
VALUES				(1,1,'joao','joao@suporte.com','suporte@132','15854089268','942381890')
					,(2,1,'robert','robert@manutenção.com', 'manutenção@132', '98764589230', '97124538')
                    ,(3,1,'lucas', 'lucas@limpeza.com', 'limpeza@132', '98765432109', '964789379');
                    
 INSERT INTO Chamado(IdChamado, descricao, tipo, IdEspecialista, IdColaborador, status, dataAbertura, dataFinalizacao, prioridade)
 VALUES 			(2, 'troca de cabos', 'Manutenção',2,1,0, '2021-11-16 13:20:00', '2021-11-16 16:49:00', 0);
 
 INSERT INTO Material(IdChamado, nome, descricao, tipo)
 VALUES 			 (2, 'cabo', 'cat5e', 'Suporte');
 
 select * from chamado