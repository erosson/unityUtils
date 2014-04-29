unityUtils
==========
erosson's commonly used Unity code.

Add to a Unity project:

    git subtree add --prefix=Assets/erossonUnityUtils https://github.com/erosson/unityUtils.git master --squash

Pull updates to this package to a Unity project:

    git subtree pull --prefix=Assets/erossonUnityUtils https://github.com/erosson/unityUtils.git --squash

Push changes to this package from a Unity project (pull first!):

    git subtree push --prefix=Assets/erossonUnityUtils https://github.com/erosson/unityUtils.git master

If that fails, or to preview changes before pushing:

    git checkout `git subtree split --prefix=Assets/erossonUnityUtils`
    git push https://github.com/erosson/unityUtils.git HEAD:master -f
