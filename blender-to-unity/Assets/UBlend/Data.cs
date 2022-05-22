using System;
using System.Collections.Generic;
using UnityEngine;

namespace UBlend{
    /// <summary>
    /// U Blend Data Class
    /// </summary>
    [Serializable]
    public class Data 
    {
        [SerializeReference]
        public UAssets u_assets = new UAssets();
        public UObjects u_objects = new UObjects();
        public USettings u_settings = new USettings();
    }

    #region Asset Defintions

    /// <summary>
    /// Container for UBlend Assets: Meshes, Materials, Textures
    /// </summary>
    [Serializable]
    public class UAssets
    {
        public List<UMesh> u_meshes = new List<UMesh>();
        public List<UMaterial> u_materials = new List<UMaterial>();
        public List<UTexture> u_textures = new List<UTexture>();
    }

    /// <summary>
    /// UBlend Mesh Description
    /// </summary>
    [Serializable]
    public class UMesh
    {
        public string u_name = "";
        public List<Vector3> u_vertices = new List<Vector3>();
        public List<Vector3> u_normals = new List<Vector3>();

        // sub meshes.
        public int u_submesh_count = 1;
        public List<SubMeshTriangles> u_submesh_triangles = new List<SubMeshTriangles>();
        public List<UUVLayer> u_uvs = new List<UUVLayer>();
    }

    [Serializable]
    public class SubMeshTriangles
    {
        public List<int> u_triangles = new List<int>();
    }

    [Serializable]
    public class UUVLayer
    {
        public List<Vector2> u_uv = new List<Vector2>();
        public UUVLayer(List<Vector2> u_uv)
        {
            this.u_uv = u_uv;
        }
    }
    /// <summary>
    /// UBlend Material Description
    /// </summary>
    [Serializable]
    public class UMaterial
    {

    }
    /// <summary>
    /// UBlend Material Description
    /// </summary>
    [Serializable]
    public class UTexture
    {

    }

    #endregion

    #region Object Defintions
    /// <summary>
    /// Container for UBlend Objects: GameObjects
    /// </summary>
    [Serializable]
    public class UObjects
    {
        public List<UGameObject> u_gameobjects = new List<UGameObject>();
    }

    /// <summary>
    /// UBlend Interpretation of a GameObject
    /// </summary>
    [Serializable]
    public class UGameObject
    {
        public string name = string.Empty;
        public UTransform u_transform = new UTransform();

        [SerializeReference]
        public List<UComponent> u_components = new List<UComponent>();

        public UComponent GetComponent(Type type)
        {
            foreach (var component in u_components)
            {
                if (component.GetType() == type)
                {
                    return component;
                }
            }
            return null;
        }
        public List<UComponent> GetComponents(Type type){
            List<UComponent> components = new List<UComponent>();
            foreach (var component in u_components)
            {
                if (component.GetType() == type)
                {
                    components.Add(component);
                }
            }
            return components;
        }
    }

    [Serializable]
    public class UComponent
    {
        
    }

    [Serializable]
    public class UTransform : UComponent
    {
        public string parent_name = string.Empty;
        public Vector3 position = Vector3.zero;
        public Vector3 rotation = Vector3.zero;
        public Vector3 scale = Vector3.zero;
    }

    [Serializable]
    public class UMeshFilter : UComponent
    {
        public string mesh_name = string.Empty;
    }

    #endregion
    [Serializable]
    public class USettings
    {

    }
}