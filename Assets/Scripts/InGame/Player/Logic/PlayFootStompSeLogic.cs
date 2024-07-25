using InGame.Player.View;
using UnityEngine;
using VContainer;

namespace InGame.Player.Logic
{
    public class PlayFootStompSeLogic
    {
        [Inject]
        public PlayFootStompSeLogic(PlayerView playerView)
        {
            PlayerView = playerView;
            GetTerrainProps();
            playerView.FootStompEvent += PlayFootStompSe;
        }

        private void PlayFootStompSe()
        {
            var index = GetTerrainAtPosition(PlayerView.ModelTransform.position);
        }
        private PlayerView PlayerView { get; }
        private TerrainData _terrainData;
        private int _alphamapWidth;
        private int _alphamapHeight;

        private float[,,] _splatmapData;
        private int _numTextures;

        private void GetTerrainProps()
        {
            _terrainData = Terrain.activeTerrain.terrainData;
            _alphamapWidth = _terrainData.alphamapWidth;
            _alphamapHeight = _terrainData.alphamapHeight;

            _splatmapData = _terrainData.GetAlphamaps(0, 0, _alphamapWidth, _alphamapHeight);
            _numTextures = _splatmapData.Length / (_alphamapWidth * _alphamapHeight);
        }

        private Vector3 ConvertToSplatMapCoordinate(Vector3 playerPos)
        {
            Vector3 vecRet = new Vector3();
            Vector3 terrainSize = _terrainData.size;
            Vector3 terPosition = Terrain.activeTerrain.transform.position;
            vecRet.x = ((playerPos.x - terPosition.x) / terrainSize.x) * _terrainData.alphamapWidth;
            vecRet.z = ((playerPos.z - terPosition.z) / terrainSize.z) * _terrainData.alphamapHeight;
            return vecRet;
        }

        private int GetActiveTerrainTextureIdx(Vector3 pos)
        {
            Vector3 terrainCord = ConvertToSplatMapCoordinate(pos);
            int ret = 0;
            float comp = 0f;
            for (int i = 0; i < _numTextures; i++)
            {
                if (comp < _splatmapData[(int)terrainCord.z, (int)terrainCord.x, i])
                    ret = i;
            }

            return ret;
        }

        private int GetTerrainAtPosition(Vector3 pos)
        {
            int terrainIdx = GetActiveTerrainTextureIdx(pos);
            return terrainIdx;
        }
    }
}