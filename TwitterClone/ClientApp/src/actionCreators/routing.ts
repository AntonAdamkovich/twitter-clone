import { push, goBack } from 'connected-react-router';

import * as Routes from '../constants/routes';

export const navigateBack = () => goBack();
export const navigateTo = (path: string) => push(path);

export const navigateToLogin = () => navigateTo(Routes.LOGIN);
export const navigateToRegistration = () => navigateTo(Routes.REGISTRATION);
