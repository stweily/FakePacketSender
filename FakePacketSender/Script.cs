﻿using System.Xml;
using System.Xml.Serialization;

namespace FakePacketSender
{
    public class Script
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public string Lua { get; set; }

        [XmlElement("Lua")]
        public XmlCDataSection _lua
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Lua))
                    return null;
                return new XmlDocument().CreateCDataSection("\n" + Lua + "\n");
              }
            set
            {
                if (value == null || string.IsNullOrWhiteSpace(value.Value))
                    Lua = string.Empty;
                Lua = value.Value.Trim();
            }
        }
    }
}
