using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DerStr1k3r.Handler
{
    class ShieldHandler : IScript
    {
        [AsyncClientEvent("Server:Shield:UseShield")]
        public async Task UseItem(RoleplayPlayer player)
        {
            try
            {
                if (!player.HasData("shield"))
                {
                    // Police Shield angelegt
                    bool shieldstate = true;
                    int istate = shieldstate ? 1 : 0;
                    player.SetStreamSyncedMetaData("shield", istate);
                    player.SetStreamSyncedMetaData("shieldstatus", istate);

                }
                else
                {
                    // Police Shield abgelegt
                    player.DeleteStreamSyncedMetaData("shield");
                    player.DeleteStreamSyncedMetaData("shieldstatus");
                }
            }

        }

        [AsyncClientEvent("playerEnteringVehicle")]
        public async Task UseItem(RoleplayPlayer player)
        {
            try
            {
                player.EmitLocked("Client:Shield:RemoveShieldForVehicle");
            }

        }

        [AsyncClientEvent("playerLeftVehicle")]
        public async Task UseItem(RoleplayPlayer player)
        {
            try
            {
                player.EmitLocked("Client:Shield:AddShieldAfterVehicle");
            }

        }
    }
}