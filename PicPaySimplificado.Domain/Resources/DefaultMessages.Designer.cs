﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PicPaySimplificado.Domain.Resources {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DefaultMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DefaultMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PicPaySimplificado.Domain.Resources.DefaultMessages", typeof(DefaultMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} já está em uso..
        /// </summary>
        public static string AlreadyUsed {
            get {
                return ResourceManager.GetString("AlreadyUsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O valor precisa ser maior do que zero..
        /// </summary>
        public static string AmountMustBeGreaterThanZero {
            get {
                return ResourceManager.GetString("AmountMustBeGreaterThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Ocorreu um erro inesperado..
        /// </summary>
        public static string GenericError {
            get {
                return ResourceManager.GetString("GenericError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Saldo insuficiente..
        /// </summary>
        public static string InsufficientBalance {
            get {
                return ResourceManager.GetString("InsufficientBalance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O formato de {0} está inválido..
        /// </summary>
        public static string InvalidFormat {
            get {
                return ResourceManager.GetString("InvalidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} é um tipo inválido..
        /// </summary>
        public static string InvalidType {
            get {
                return ResourceManager.GetString("InvalidType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Lojista não pode fazer transferências..
        /// </summary>
        public static string MerchantCantBeAPayer {
            get {
                return ResourceManager.GetString("MerchantCantBeAPayer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} deve ter no mínimo {1} caractere(s)..
        /// </summary>
        public static string MinimumLengthRequired {
            get {
                return ResourceManager.GetString("MinimumLengthRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} não encontrado..
        /// </summary>
        public static string NotFound {
            get {
                return ResourceManager.GetString("NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} é um campo obrigatório..
        /// </summary>
        public static string RequiredField {
            get {
                return ResourceManager.GetString("RequiredField", resourceCulture);
            }
        }
    }
}
