using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filecontroller : MonoBehaviour
{
    #region setup
    [Header("File Depth")]
    public int Depth=1;
    //1 root
    //2 1 deep
    //3 2 deep
    [Header("Previous File")]
    public int localroot;
    //1 rootpos1
    //2 rootpos2
    //3 rootpos3
    //4 rootpos4
    //5 1dpos1
    //6 1dpos2
    //7 1dpos3
    //8 1dpos4
    [Header("File Positions")]
    public List<GameObject> positions;
    [Header("Folders")]
    public List<GameObject> folders;
    [Header("Content Files")]
    public List<GameObject> contentFiles;
    #endregion
    public void Update()
    {
        switch (Depth)
        {
            #region root
            case 1:
                foreach (GameObject go in folders)
                {
                    if (folders.IndexOf(go) < 2)
                    {
                        go.SetActive(true);
                    }
                    else
                    {
                        go.SetActive(false);
                    }
                }
                break;
            #endregion
            #region depth2
            case 2:
                switch (localroot)
                {
                    case 1:
                        foreach (GameObject go in folders)
                        {
                            if (folders.IndexOf(go) < 6 && folders.IndexOf(go) > 2)
                            {
                                go.SetActive(true);
                            }
                            else
                            {
                                go.SetActive(false);
                            }
                        }
                        break;
                    case 2:
                        foreach (GameObject go in folders)
                        {
                            if (folders.IndexOf(go) < 7 && folders.IndexOf(go) > 5)
                            {
                                go.SetActive(true);
                            }
                            else
                            {
                                go.SetActive(false);
                            }
                        }
                        break;
                    case 3:
                        foreach (GameObject go in folders)
                        {
                            if (folders.IndexOf(go) < 8 && folders.IndexOf(go) > 6)
                            {
                                go.SetActive(true);
                            }
                            else
                            {
                                go.SetActive(false);
                            }
                        }
                        break;
                    case 4:
                        foreach (GameObject cf in contentFiles)
                        {
                            if (contentFiles.IndexOf(cf) < 3)
                            {
                                cf.SetActive(true);
                            }
                            else
                            {
                                cf.SetActive(false);
                                foreach (GameObject go in folders)
                                {
                                    go.SetActive(false);
                                }
                            }
                        }
                        break;
                }
                break;
                
            #endregion
            #region depth3
            case 3:
                switch (localroot)
                {
                    case 5:
                        foreach (GameObject cf in contentFiles)
                        {
                            if (contentFiles.IndexOf(cf) < 3 && contentFiles.IndexOf(cf) > 7)
                            {
                                cf.SetActive(true);
                            }
                            else
                            {
                                cf.SetActive(false);
                                foreach (GameObject go in folders)
                                {
                                    go.SetActive(false);
                                }
                            }
                        }
                        break;
                    case 6:
                        foreach (GameObject cf in contentFiles)
                        {
                            cf.SetActive(false);
                        }
                        foreach (GameObject go in folders)
                        {
                            go.SetActive(false);
                        }
                        break;
                    case 7:
                        foreach (GameObject cf in contentFiles)
                        {
                            if (contentFiles.IndexOf(cf) < 6 && contentFiles.IndexOf(cf) > 9)
                            {
                                cf.SetActive(true);
                            }
                            else
                            {
                                cf.SetActive(false);
                                foreach (GameObject go in folders)
                                {
                                    go.SetActive(false);
                                }
                            }
                        }
                        break;
                    case 8:
                        foreach (GameObject cf in contentFiles)
                        {
                            if (contentFiles.IndexOf(cf) < 8 && contentFiles.IndexOf(cf) > 11)
                            {
                                cf.SetActive(true);
                            }
                            else
                            {
                                cf.SetActive(false);
                            }
                        }
                        break;
                }
                break;
                
            #endregion
        }
    }
}
