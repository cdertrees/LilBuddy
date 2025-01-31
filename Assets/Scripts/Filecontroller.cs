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

    public void Start()
    {
        change();
    }

    public void change()
    {
        switch (Depth)
        {
            #region root
            case 1:
                foreach (GameObject go in folders)
                {
                    if (folders.IndexOf(go) < 4)
                    {
                        go.SetActive(true);
                    }
                    else
                    {
                        go.SetActive(false);
                    }
                }
                foreach (GameObject cf in contentFiles)
                {
                    cf.SetActive(false);
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
                            if (folders.IndexOf(go) < 6 && folders.IndexOf(go) > 3)
                            {
                                go.SetActive(true);
                            }
                            else
                            {
                                go.SetActive(false);
                            }
                        }
                        foreach (GameObject cf in contentFiles)
                        {
                            if (contentFiles.IndexOf(cf) < 2)
                            {
                                cf.SetActive(true);
                            }
                            else
                            {
                                cf.SetActive(false);
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
                            if (folders.IndexOf(go) < 9 && folders.IndexOf(go) > 6)
                            {
                                go.SetActive(true);
                            }
                            else
                            {
                                go.SetActive(false);
                            }
                        }
                        foreach (GameObject cf in contentFiles)
                        {
                            if (contentFiles.IndexOf(cf) < 3 && contentFiles.IndexOf(cf) > 1)
                            {
                                cf.SetActive(true);
                            }
                            else
                            {
                                cf.SetActive(false);
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
                                
                            }
                        }   
                        foreach (GameObject go in folders)
                        {
                            go.SetActive(false);
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

    public void navigate(int f)
    {
        switch (f)
        {
            case 1:
                Depth = 2;
                localroot = 1;
                break;
            case 2:
                Depth = 2;
                localroot = 2;
                break;
            case 3:
                Depth = 2;
                localroot = 3;
                break;
            case 4:
                Depth = 2;
                localroot = 4;
                break;
            case 5:
                Depth = 3;
                localroot = 5;
                break;
            case 6:
                Depth = 3;
                localroot = 6;
                break;
            case 7:
                Depth = 3;
                localroot = 7;
                break;
            case 8:
                Depth = 3;
                localroot = 8;
                break;
            case 9:
                contentserver temp = (contentserver)contentFiles[0].GetComponent(typeof(contentserver));
                temp.openWindow();
                break;
            case 10:
                contentserver temp2 = (contentserver)contentFiles[1].GetComponent(typeof(contentserver));
                temp2.openWindow();
                break;
            case 11:
                contentserver temp3 = (contentserver)contentFiles[2].GetComponent(typeof(contentserver));
                temp3.openWindow();
                break;
            case 12:
                switch (localroot)
                {
                    case 1:
                        Depth = 1;
                        localroot = 0;
                        break;
                    case 2:
                        Depth = 1;
                        localroot = 0;
                        break;
                    case 3:
                        Depth = 1;
                        localroot = 0;
                        break;
                    case 4:
                        Depth = 1;
                        localroot = 0;
                        break;
                    case 5:
                        Depth = 2;
                        localroot = 1;
                        break;
                    case 6:
                        Depth = 2;
                        localroot = 1;
                        break;
                    case 7:
                        Depth = 2;
                        localroot = 2;
                        break;
                    case 8:
                        Depth = 2;
                        localroot = 4;
                        break;
                }
                break;
        }
        change();
    }
}
